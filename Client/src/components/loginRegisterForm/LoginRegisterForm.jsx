import {React, useState} from "react";
import axios from "axios";
import "./LoginRegisterForm.css";

export default function LoginRegisterForm({title, url}) {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const handleSubmit = async () => {
        try {
            const response = await axios.post(url, { email, password });
            console.log(response);
        } catch (error) {
            console.log(error); 
        }
    };

    return (
        <div className="register-login">
            <h1>{title}</h1>
            <div className="register-login-form">
                <input
                    type="text"
                    placeholder="Email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    name="email"
                />
                <input
                    type="password"
                    placeholder="Password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    name="password"
                />
                <button onClick={handleSubmit}>{title}</button>
            </div>
        </div>
    );
}