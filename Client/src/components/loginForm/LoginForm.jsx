import React from "react";
import axios from "axios";
import "../../components/shared/LoginRegisterForm.css";

export default function LoginForm(url) {
    const [email, setEmail] = React.useState("");
    const [password, setPassword] = React.useState("");
    const handleSubmit = async () => {
        try {
            const response = await axios.post(url, { email, password });
            console.log(response);
        } catch (error) {
            console.log(error.response.data);
        }    };

    return (
      <div className="login-form">
        <h1>Login</h1>
        <input
          type="email"
          placeholder="Email"
          value={email}
          name="email"
          onChange={(e) => setEmail(e.target.value)}
        />
        <input
          type="password"
          placeholder="Password"
          value={password}
          name = "password"
          onChange={(e) => setPassword(e.target.value)}
        />
        <button onClick={handleSubmit}>Login</button>
      </div>
    );
}