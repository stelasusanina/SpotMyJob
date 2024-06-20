import React from "react";
import LoginRegisterForm from "../../components/loginRegisterForm/LoginRegisterForm";

export default function Register() {
  return (
    <LoginRegisterForm
      title="Register"
      url="https://localhost:7212/api/auth/register"
    />
  );
}
