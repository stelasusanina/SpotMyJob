import { createContext, useContext, useState } from "react";
import axios from "axios";

const AuthContext = createContext();

export function useAuth() {
    return useContext(AuthContext);
}

export function AuthProvider (props){
    const [user, setUser] = useState(null);
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    
    const login = (userData) => {
        setUser(userData);
        setIsLoggedIn(true);
    };

    const logout = async () => {
        try {
            const response = await axios.post(
              `${process.env.REACT_APP_API_BASE_URL}/auth/logout`,
              {}, 
              { withCredentials: true }
            );
      
            if (response.status === 200) {
              setIsLoggedIn(false);
              setUser(null);
            } else {
              console.error("Logout failed:", response.statusText);
            }
          } catch (error) {
            console.error("Logout failed:", error);
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
        <AuthContext.Provider value={value}>
            {props.children}
        </AuthContext.Provider>
    );
};
