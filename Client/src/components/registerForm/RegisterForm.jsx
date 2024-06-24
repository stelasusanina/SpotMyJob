import React from "react";
import axios from "axios";
import "../../components/shared/LoginRegisterForm.css";
import LoginRegisterInput from "../loginRegisterInput/LoginRegisterInput";

export default function RegisterForm({ url }) {
    const [firstName, setFirstName] = React.useState("");
    const [lastName, setLastName] = React.useState("");
    const [email, setEmail] = React.useState("");
    const [password, setPassword] = React.useState("");
    const [confirmPassword, setConfirmPassword] = React.useState("");
    const [phoneNumber, setPhoneNumber] = React.useState("");

    const data = {
        firstName,
        lastName,
        email,
        phoneNumber,
        password,
        confirmPassword,
    }
    const handleSubmit = async () => {
        try {
            const response = await axios.post(url, data);
            console.log(response);
        } catch (error) {
            console.log(error.response);
        }
    };

    return (
      <div className="register-form">
        <h1>Register</h1>
        <div className="form-group">
          <LoginRegisterInput
            placeholder="First Name"
            type="text"
            name="firstName"
            onChange={(e) => setFirstName(e.target.value)}
          />
          <LoginRegisterInput
            placeholder="Last Name"
            type="text"
            name="lastName"
            onChange={(e) => setLastName(e.target.value)}
          />
        </div>
        <div className="form-group">
          <LoginRegisterInput
            placeholder="Email"
            type="email"
            name="email"
            onChange={(e) => setEmail(e.target.value)}
          />
          <LoginRegisterInput
            placeholder="Phone Number"
            type="tel"
            name="phoneNumber"
            onChange={(e) => setPhoneNumber(e.target.value)}
          />
        </div>
        <div className="form-group">
          <LoginRegisterInput
            placeholder="Password"
            type="password"
            name="password"
            onChange={(e) => setPassword(e.target.value)}
          />
          <LoginRegisterInput
            placeholder="Confirm Password"
            type="password"
            name="confirmPassword"
            onChange={(e) => setConfirmPassword(e.target.value)}
          />
        </div>
        <button onClick={handleSubmit}>Register</button>
      </div>
    );}
