import React, { useState } from "react";
import "./Login.css";
import LoginRegisterForm from "../../components/loginRegisterForm/LoginRegisterForm";

export default function Login() {
    return(
        <LoginRegisterForm
            title="Login"
            url="/api/auth/login"
        />
    )
}
