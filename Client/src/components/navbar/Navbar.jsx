import React, { useState, useEffect } from "react";
import { Link, useLocation, useNavigate } from "react-router-dom";
import "./Navbar.css";
import logo from "../../photos/logo.jpg";
import { useAuth } from "../../contexts/AuthContext";
import { toast } from "react-toastify";
import "../../shared/ToastifyStyles.css";

export default function Navbar() {
  const location = useLocation();
  const navigate = useNavigate();
  const [activePath, setActivePath] = useState(location.pathname);
  const { isLoggedIn, logout } = useAuth();

  useEffect(() => {
    setActivePath(location.pathname);
  }, [location]);

  const navBarStyle = {
    marginBottom: activePath === "/" ? "0px" : "20px",
  };

  const notify = () =>
    toast(<span>You have successfully logged out!</span>, {
      className: "--toastify-color-success",
    });

  const logoutUser = () => {
    logout();
    notify();
    navigate("/");
  };

  return (
    <div className="nav-bar-container" style={navBarStyle}>
      <nav className="nav-bar">
        <img className="logo" src={logo} alt="logo" />
        <ul>
          <div className="common">
            <li>
              <Link to="/" className={activePath === "/" ? "active" : ""}>
                Home
              </Link>
            </li>
            <li>
              <Link
                to="/jobs"
                className={activePath === "/jobs" ? "active" : ""}>
                Jobs
              </Link>
            </li>
          </div>
          {!isLoggedIn ? (
            <div className="logged-out">
              <li>
                <Link
                  to="/auth/login"
                  className={activePath === "/auth/login" ? "active" : ""}>
                  Login
                </Link>
              </li>
              <li>
                <Link
                  to="/auth/register"
                  className={activePath === "/auth/register" ? "active" : ""}>
                  Register
                </Link>
              </li>
            </div>
          ) : (
            <div className="logged-in">
              <li>
                <Link
                  to="/myProfile"
                  className={activePath === "/myProfile" ? "active" : ""}>
                  My Profile
                </Link>
              </li>
              <li>
                <button className="logout-button" onClick={logoutUser}>
                  Logout
                </button>
              </li>
            </div>
          )}
        </ul>
      </nav>
    </div>
  );
}
