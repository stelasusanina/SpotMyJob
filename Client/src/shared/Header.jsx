import React from "react";
import {Link} from "react-router-dom";
import "./Header.css";

export default function Layout() {
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