import React from "react";
import {Link} from "react-router-dom";
import "./Navbar.css";

export default function Navbar() {
    return (
        <div>
            <nav className="nav-bar">
                <ul>
                    <li><Link to="/">Home</Link></li>
                    <li><Link to="/jobs">Jobs</Link></li>
                    <li><Link to="/login">Login</Link></li>
                </ul>
            </nav>
        </div>
    )
}