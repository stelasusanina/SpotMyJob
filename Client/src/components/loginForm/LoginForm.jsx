import React from "react";
import axios from "axios";
import { useFormik } from "formik";
import * as yup from "yup";
import { useNavigate } from "react-router-dom";
import "../shared/LoginRegisterForm.css";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import "../../shared/ToastifyStyles.css";
import { useAuth } from "../../contexts/AuthContext";
import Cookies from "js-cookie";

const schema = yup.object().shape({
  email: yup.string().required("Email is required"),
  password: yup.string().required("Password is required"),
});

export default function LoginForm() {
  const navigate = useNavigate();
  const{ login, cookie } = useAuth();

  const notify = (firstName, lastName) =>
    toast(
      <span>
        Welcome,{" "}
        <span className="names">
          {firstName} {lastName}
        </span>
        !
      </span>,
      {
        className: "--toastify-color-success",
      }
    );

  const formik = useFormik({
    initialValues: {
      email: "",
      password: "",
    },
    validationSchema: schema,
    onSubmit: async (values) => {
      try {
        const response = await axios.post(
          `${process.env.REACT_APP_API_BASE_URL}/auth/login`,
          values,
          { withCredentials: true }
        );

        if (response.status === 200) {
          notify(response.data.firstName, response.data.lastName);
          navigate("/");
          login(response.data);
        }
      } catch (error) {
        if (error.response.data.message === "Invalid login attempt") {
          formik.setErrors({ password: "Invalid email or password" });
        }
      }
    },
  });

  return (
    <div className="login-form">
      <h1>Login</h1>
      <form onSubmit={formik.handleSubmit}>
        <div className="input-group">
          <input
            placeholder="Email"
            type="email"
            name="email"
            value={formik.values.email}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.email && formik.errors.email ? (
            <span className="error">{formik.errors.email}</span>
          ) : null}
        </div>

        <div className="input-group">
          <input
            type="password"
            placeholder="Password"
            name="password"
            value={formik.values.password}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.password && formik.errors.password ? (
            <span className="error">{formik.errors.password}</span>
          ) : null}
        </div>

        <button type="submit">Login</button>
      </form>
    </div>
  );
}
