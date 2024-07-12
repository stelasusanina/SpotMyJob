import React from "react";
import { useFormik } from "formik";
import * as yup from "yup";
import "../shared/LoginRegisterForm.css";
import "react-toastify/dist/ReactToastify.css";
import "../../shared/ToastifyStyles.css";
import { useAuth } from "../../contexts/AuthContext";
import { useNavigate } from "react-router-dom";

const schema = yup.object().shape({
  email: yup.string().required("Email is required"),
  password: yup.string().required("Password is required"),
});

export default function LoginForm() {
  const { login } = useAuth();
  const navigate = useNavigate();

  const formik = useFormik({
    initialValues: {
      email: "",
      password: "",
    },
    validationSchema: schema,
    onSubmit: async (values) => {
      try {
        const response = await login(values);
        if (response) {
          navigate("/");
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
