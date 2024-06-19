import React from "react";
import LoginRegisterForm from "../../components/loginRegisterForm/LoginRegisterForm";

export default function Register() {
    return (
        <LoginRegisterForm
            title="Register"
            url="/api/auth/register"
        />
    )
}