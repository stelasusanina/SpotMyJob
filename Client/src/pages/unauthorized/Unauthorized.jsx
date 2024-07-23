import React from "react";
import "./Unauthorized.css";

export default function Unauthorized() {
    return (
      <div className="unauthorized">
        <h1 className="unauthorized-title">403</h1>
        <h3>Access denied</h3>
        <p>You do not have permission to access this page.</p>
      </div>
    );
}