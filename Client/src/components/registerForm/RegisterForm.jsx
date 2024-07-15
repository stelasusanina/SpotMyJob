import React from "react";
import { useFormik } from "formik";
import * as yup from "yup";
import axios from "axios";
import "../shared/LoginRegisterForm.css";
import { useAuth } from "../../contexts/AuthContext";
import "../../shared/ToastifyStyles.css";
import { useNavigate } from "react-router-dom";

const schema = yup.object().shape({
  firstName: yup
    .string()
    .required("First name is required")
    .min(2, "First name must be at least 2 characters"),
  lastName: yup
    .string()
    .required("Last name is required")
    .min(2, "Last name must be at least 2 characters"),
  email: yup
    .string()
    .matches(/^\S+@\S+\.\S+$/, "Invalid email address")
    .required("Email is required"),
  phoneNumber: yup
    .string()
    .matches(/^\d{10}$/, "Phone number must be 10 digits")
    .required("Phone number is required"),
  password: yup
    .string()
    .min(8, "Password must be at least 8 characters")
    .matches(/[A-Z]/, "Password must contain at least one uppercase letter")
    .matches(/[a-z]/, "Password must contain at least one lowercase letter")
    .required("Password is required"),
  confirmPassword: yup
    .string()
    .oneOf([yup.ref("password"), null], "Passwords must match")
    .required("Confirm password is required"),
});

export default function RegisterForm() {
  const {login} = useAuth();
  const navigate = useNavigate();

  const formik = useFormik({
    initialValues: {
      firstName: "",
      lastName: "",
      email: "",
      phoneNumber: "",
      password: "",
      confirmPassword: "",
    },
    validationSchema: schema,
    onSubmit: async (values) => {
      try {
        const response = await axios.post(
          `${process.env.REACT_APP_API_BASE_URL}/auth/register`,
          values
        );

        console.log(response.data);

        if (response.status === 200) {
          await login({
            email: values.email,
            password: values.password,
          });

          navigate("/");
        }
        else{
          console.log(response.data);
        }
      } catch (error) {
        console.log(error.response.data);
        if (error.response.data[0].code === "DuplicateUserName") {
          formik.setFieldError("email", "Email already exists");
        }
      }
    },
  });

  return (
    <div className="register-form">
      <h1>Register</h1>
      <form onSubmit={formik.handleSubmit}>
        <div className="form-group">
          <div className="relative">
            <input
              name="firstName"
              placeholder="First Name"
              value={formik.values.firstName}
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
            />
            {formik.touched.firstName && formik.errors.firstName && (
              <div className="error">{formik.errors.firstName}</div>
            )}
          </div>

          <div className="relative">
            <input
              name="lastName"
              placeholder="Last Name"
              value={formik.values.lastName}
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
            />
            {formik.touched.lastName && formik.errors.lastName && (
              <div className="error">{formik.errors.lastName}</div>
            )}
          </div>
        </div>

        <div className="form-group">
          <div className="relative">
            <input
              name="phoneNumber"
              placeholder="Phone number"
              value={formik.values.phoneNumber}
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
            />
            {formik.touched.phoneNumber && formik.errors.phoneNumber && (
              <div className="error">{formik.errors.phoneNumber}</div>
            )}
          </div>

          <div className="relative">
            <input
              name="email"
              placeholder="Email"
              value={formik.values.email}
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
            />
            {formik.touched.email && formik.errors.email && (
              <div className="error">{formik.errors.email}</div>
            )}
          </div>
        </div>

        <div className="form-group">
          <div className="relative">
            <input
              name="password"
              placeholder="Password"
              type="password"
              value={formik.values.password}
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
            />
            {formik.touched.password && formik.errors.password && (
              <div className="error">{formik.errors.password}</div>
            )}
          </div>

          <div className="relative">
            <input
              name="confirmPassword"
              placeholder="Confirm Password"
              type="password"
              value={formik.values.confirmPassword}
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
            />
            {formik.touched.confirmPassword &&
              formik.errors.confirmPassword && (
                <div className="error">{formik.errors.confirmPassword}</div>
              )}
          </div>
        </div>
        <button className="register-form-button" type="submit">Submit</button>
      </form>
    </div>
  );
}
