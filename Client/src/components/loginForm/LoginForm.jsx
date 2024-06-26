import React from "react";
import axios from "axios";
import { useFormik } from "formik";
import * as yup from "yup";
import "../shared/LoginRegisterForm.css";

const schema = yup.object().shape({
  email: yup.string().required("Email is required"),
  password: yup.string().required("Password is required"),
});

export default function LoginForm() {
  const formik = useFormik({
    initialValues: {
      email: "",
      password: "",
    },
    validationSchema: schema,
    onSubmit: async (values) => {
      try {
        const response = await axios.post("https://localhost:7212/api/auth/login", values);
        console.log(response);
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
