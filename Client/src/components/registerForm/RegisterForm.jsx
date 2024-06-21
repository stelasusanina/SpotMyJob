import React from "react";
import axios from "axios";
import "../../components/shared/LoginRegisterForm.css";

export default function RegisterForm(url) {
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
            console.log(error.response.data);
        }
    };


    return (
        <div className="register-form">
            <h1>Register</h1>
            <div className="form-group">
              <input
                type="text"
                placeholder="First Name"
                value={firstName}
                name="firstName"
                onChange={(e) => setFirstName(e.target.value)}
              />
              <input
                type="text"
                placeholder="Last Name"
                value={lastName}
                name="lastName"
                onChange={(e) => setLastName(e.target.value)}
              />
            </div>
            <div className="form-group">
              <input
                type="email"
                placeholder="Email"
                value={email}
                name="email"
                onChange={(e) => setEmail(e.target.value)}
              />
              <input
                type="phone"
                placeholder="Phone Number"
                value={phoneNumber}
                name="phoneNumber"
                onChange={(e) => setPhoneNumber(e.target.value)}
              />
            </div>
            <div className="form-group">
              <input
                type="password"
                placeholder="Password"
                value={password}
                name="password"
                onChange={(e) => setPassword(e.target.value)}
              />
              <input
                type="password"
                placeholder="Confirm Password"
                value={confirmPassword}
                name="confirmPassword"
                onChange={(e) => setConfirmPassword(e.target.value)}
              />
            </div>
            <button onClick={handleSubmit}>Register</button>
        </div>
        )}
