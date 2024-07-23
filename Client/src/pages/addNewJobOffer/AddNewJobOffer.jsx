import React, { useState, useEffect } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { useFormik } from "formik";
import * as yup from "yup";
import { useAuth } from "../../contexts/AuthContext";
import "./AddNewJobOffer.css";

const schema = yup.object().shape({
  title: yup.string().required("Job title is required"),
  country: yup.string().required("Country is required"),
  city: yup.string().required("City is required"),
  companyName: yup.string().required("Company name is required"),
  companyDescription: yup.string(),
  companyImgUrl: yup.string().required("Company image URL is required"),
  jobCategoryId: yup.string().required("Job category is required"),
  sections: yup
    .array()
    .of(
      yup.object().shape({
        Name: yup.string().required("Section name is required"),
        Content: yup.string().required("Section content is required"),
      })
    )
    .min(3, "All sections are required"),
});

export default function AddNewJobOffer() {
  const navigate = useNavigate();
  const {getRole} = useAuth();
  const [role, setRole] = useState(null);
  const [jobCategories, setJobCategories] = useState([]);

  const formik = useFormik({
    initialValues: {
      title: "",
      country: "",
      city: "",
      companyImgUrl: "",
      isFullTime: false,
      companyName: "",
      companyDescription: "",
      jobCategoryId: "",
      sections: [
        { Name: "Requirements", Content: "" },
        { Name: "Responsibilities", Content: "" },
        { Name: "Benefits", Content: "" }
      ]
    },
    validationSchema: schema,
    onSubmit: async (values) => {
      console.log("Data being sent:", values);

      try {
        const response = await axios.post(
          `${process.env.REACT_APP_API_BASE_URL}/admin/addJobOffer`,
          values
        );
        console.log("Response from API:", response);
        navigate("/jobs");
      } catch (error) {
        console.log(error);
      }
    },
  });

  useEffect(() => {
    const fetchRole = async () => {
        const response = await getRole();
        setRole(response);
        console.log(response.data);
    }
    const fetchJobCategories = async () => {
      try {
        const response = await axios.get(
          `${process.env.REACT_APP_API_BASE_URL}/home`
        );
        setJobCategories(response.data);
      } catch (error) {
        console.error("Error fetching job categories:", error);
      }
    };

    fetchJobCategories();
    fetchRole();
  }, [role, getRole]);


  if(role !== "Admin"){
    
  }
  return (
    <div className="form-container">
      <h3>Add New Job Offer</h3>
      <form onSubmit={formik.handleSubmit}>
        <div className="form-group">
          <input
            className="form-input"
            name="title"
            placeholder="Title"
            value={formik.values.title}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.title && formik.errors.title ? (
            <div className="error add-job">{formik.errors.title}</div>
          ) : null}
        </div>

        <div className="form-group">
          <input
            className="form-input"
            name="country"
            placeholder="Country"
            value={formik.values.country}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.country && formik.errors.country ? (
            <div className="error add-job">{formik.errors.country}</div>
          ) : null}
        </div>

        <div className="form-group">
          <input
            className="form-input"
            name="city"
            placeholder="City"
            value={formik.values.city}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.city && formik.errors.city ? (
            <div className="error add-job">{formik.errors.city}</div>
          ) : null}
        </div>

        <div className="form-group">
          <input
            className="form-input"
            name="companyImgUrl"
            placeholder="Company image URL"
            value={formik.values.companyImgUrl}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.companyImgUrl && formik.errors.companyImgUrl ? (
            <div className="error add-job">{formik.errors.companyImgUrl}</div>
          ) : null}
        </div>

        <div className="form-group form-group-checkbox">
          <label>
            <input
              name="isFullTime"
              type="checkbox"
              checked={formik.values.isFullTime}
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
            />
            Full-time
          </label>
        </div>

        <div className="form-group">
          <input
            className="form-input"
            name="companyName"
            placeholder="Company name"
            value={formik.values.companyName}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.companyName && formik.errors.companyName ? (
            <div className="error add-job">{formik.errors.companyName}</div>
          ) : null}
        </div>

        <div className="form-group">
          <textarea
            className="form-input"
            name="companyDescription"
            placeholder="Company description"
            value={formik.values.companyDescription}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.companyDescription &&
          formik.errors.companyDescription ? (
            <div className="error add-job">{formik.errors.companyDescription}</div>
          ) : null}
        </div>

        <div className="form-group">
          <select
            name="jobCategoryId"
            value={formik.values.jobCategoryId}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            className="form-input choose-category">
            <option value="" disabled>
              Choose category
            </option>
            {jobCategories.map((jobCategory) => (
              <option key={jobCategory.id} value={jobCategory.id}>
                {jobCategory.name}
              </option>
            ))}
          </select>
          {formik.touched.jobCategoryId && formik.errors.jobCategoryId ? (
            <div className="error add-job">{formik.errors.jobCategoryId}</div>
          ) : null}
        </div>

        <div className="form-group">
          <textarea
            className="form-input"
            name="sections[0].Content"
            placeholder="Requirements"
            value={formik.values.sections[0].Content}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.sections && formik.errors.sections ? (
            <div className="error add-job">{formik.errors.sections[0]?.Content}</div>
          ) : null}
        </div>

        <div className="form-group">
          <textarea
            className="form-input"
            name="sections[1].Content"
            placeholder="Responsibilities"
            value={formik.values.sections[1].Content}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.sections && formik.errors.sections ? (
            <div className="error add-job">{formik.errors.sections[1]?.Content}</div>
          ) : null}
        </div>

        <div className="form-group">
          <textarea
            className="form-input"
            name="sections[2].Content"
            placeholder="Benefits"
            value={formik.values.sections[2].Content}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.sections && formik.errors.sections ? (
            <div className="error add-job">{formik.errors.sections[2]?.Content}</div>
          ) : null}
        </div>

        <button className="btn" type="submit">
          Submit
        </button>
      </form>
    </div>
  );
}
