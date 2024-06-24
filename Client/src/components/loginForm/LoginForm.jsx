import React from "react";
import axios from "axios";
import LoginRegisterInput from "../loginRegisterInput/LoginRegisterInput";

export default function LoginForm({ url }) {
  const [email, setEmail] = React.useState("");
  const [password, setPassword] = React.useState("");
  const handleSubmit = async () => {
    try {
      const response = await axios.post(url, { email, password });
      console.log(response);
    } catch (error) {
      console.log(error.response);
    }
  };

  return (
    <div className="login-form">
      <h1>Login</h1>
      <LoginRegisterInput 
        placeholder="Email"
        type="email"
        name="email"
        onChange={(event) => setEmail(event.target.value)}
      />
      <LoginRegisterInput
        type="password"
        placeholder="Password"
        name="password"
        onChange={(event) => setPassword(event.target.value)}
      />
      <button onClick={handleSubmit}>Login</button>
    </div>
  );
}
