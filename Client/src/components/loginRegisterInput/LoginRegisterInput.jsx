import React from "react";
import "../loginRegisterInput/LoginRegisterInput.css";

const validateInput = (input, name) =>{
    let errorMessage = "";

    switch (name) {
      case "email":
        if (!/\S+@\S+\.\S+/.test(input)) {
          errorMessage = "Input is not a valid email.";
        }
        break;
      case "password":
        if (input.length < 8) {
          errorMessage = "Password is too short.";
        }
        break;
      case "firstName":
        if (input.length < 2) {
          errorMessage = "First name is too short.";
        }
        break;
      case "lastName":
        if (input.length < 2) {
          errorMessage = "Last name is too short.";
        }
        break;
      case "phoneNumber":
        if (input.length !== 10) {
          errorMessage = "Phone number must be 10 digits.";
        }
        break;
      default:
        break;
    }
    return errorMessage;
}

export default function LoginRegisterInput({placeholder, type, name}) {
    const [value, setValue] = React.useState("");
    const [error, setError] = React.useState("");

    const onChange = (event) => {
        const inputValue = event.target.value;
        setValue(inputValue);

        const errorMessage = validateInput(inputValue, name);
        setError(errorMessage);
    };

    return (
        <div className="login-register-input">
            <input
                type={type}
                value={value}
                placeholder={placeholder}
                name={name}
                onChange={onChange}
            />
            {error && <span>⚠︎ {error}</span>}
        </div>
    )
}