import { createContext, useContext, useEffect, useState } from "react";
import { toast } from "react-toastify";
import Cookies from "js-cookie";
import axiosClient from "../shared/axiosClient";

const AuthContext = createContext();

export function useAuth() {
  return useContext(AuthContext);
}

export function AuthProvider(props) {
  const [user, setUser] = useState(null);
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const notifyLogin = (firstName, lastName) =>
    toast(
      <span>
        Welcome,{" "}
        <span className="names">
          {firstName} {lastName}
        </span>
        !
      </span>,
      {
        className: "--toastify-color-success",
      }
    );

  const notifyLogout = () =>
    toast(<span>You have successfully logged out!</span>, {
      className: "--toastify-color-success",
    });

  useEffect(async () => {
    const cookie = Cookies.get(".AspNetCore.Identity.Application");
    if (cookie) {
      try {
        const response = await axiosClient.get(
          `${process.env.REACT_APP_API_BASE_URL}/auth/identify`
        );
        setIsLoggedIn(true);
        setUser();
      } catch (error) {
        setIsLoggedIn(false);
        setUser(null);
      }
    }
  }, []);

  const login = async (userData) => {
    try {
      const response = await axiosClient.post(
        `${process.env.REACT_APP_API_BASE_URL}/auth/login`,
        userData,
        { withCredentials: true }
      );

      if (response.status === 200) {
        notifyLogin(response.data.firstName, response.data.lastName);
        setUser(response.data);
        setIsLoggedIn(true);
        return response.data;
      }
    } catch (error) {
      if (error.response?.data?.message === "Invalid login attempt") {
        toast.error("Invalid email or password");
      } else {
        console.error("Login failed:", error);
        toast.error("An error occurred during login");
      }
    }
  };

  const logout = async () => {
    try {
      const response = await axiosClient.post(
        `${process.env.REACT_APP_API_BASE_URL}/auth/logout`,
        {},
        { withCredentials: true }
      );

      if (response.status === 200) {
        setIsLoggedIn(false);
        setUser(null);
        notifyLogout();
      }
    } catch (error) {
      console.error("Logout failed:", error);
      toast.error("An error occurred during logout");
    }
  };

  const value = {
    user,
    setUser,
    isLoggedIn,
    setIsLoggedIn,
    login,
    logout,
  };

  return (
    <AuthContext.Provider value={value}>{props.children}</AuthContext.Provider>
  );
}
