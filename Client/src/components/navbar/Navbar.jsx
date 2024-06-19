import React, { useState, useEffect } from "react";
import { Link, useLocation } from "react-router-dom";
import "./Navbar.css";
import logo from "../../photos/logo.jpg";

export default function Navbar() {
    const location = useLocation();
    const [activePath, setActivePath] = useState(location.pathname);

    useEffect(() => {
        setActivePath(location.pathname);
    }, [location]);

    return (
        <div className="nav-bar-container">
            <nav className="nav-bar">
                <img className="logo" src={logo} alt="logo" />
                <ul>
                    <li>
                        <Link to="/" className={activePath === "/" ? "active" : ""}>Home</Link>
                    </li>
                    <li>
                        <Link to="/jobs" className={activePath === "/jobs" ? "active" : ""}>Jobs</Link>
                    </li>
                    <li>
                        <Link to="/auth/login" className={activePath === "/auth/login" ? "active" : ""}>Login</Link>
                    </li>
                </ul>
            </nav>
        </div>
    );
}
