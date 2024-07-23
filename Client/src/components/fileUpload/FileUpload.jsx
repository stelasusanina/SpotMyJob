import React, { useState } from "react";
import { useAuth } from "../../contexts/AuthContext";
import axiosClient from "../../shared/axiosClient";
import "./FileUpload.css";
import { toast } from "react-toastify";
import { Link, useNavigate } from "react-router-dom";

export default function FileUpload({ jobId, hasApplied, jobTitle, company }) {
  const [file, setFile] = useState(null);
  const { identify } = useAuth();
  const navigate = useNavigate();

  const notifyApplication = (jobTitle, company) =>
    toast(
      <span>
        You successfully applied for <span className="names">{jobTitle}</span>{" "}
        at <span className="names">{company}</span>!
      </span>,
      {
        className: "--toastify-color-success",
      }
    );

  const handleFileChoosing = (event) => {
    setFile(event.target.files[0]);
  };

  const handleApplication = async () => {
    const userId = await identify();

    const formData = new FormData();
    formData.append("userId", userId);
    formData.append("file", file);

    axiosClient
      .post(`${process.env.REACT_APP_API_BASE_URL}/jobs/${jobId}`, formData)
      .then((response) => {
        notifyApplication(jobTitle, company);
        navigate("/jobs");
      })
      .catch((error) => {
        console.log(error);
      });
  };

  return (
    <div className="apply-to-job">
      {hasApplied ? (
        <p className="already-applied">You have already applied to this job. <Link to="/myProfile" className="link-myProfile">See your applications</Link></p>
      ) : (
        <div>
          <input
            className="choose-file"
            disabled={file}
            type="file"
            onChange={handleFileChoosing}
          />
          {file && (
            <button className="remove-file" onClick={() => setFile(null)}>
              X
            </button>
          )}
          <button
            className="apply"
            disabled={!file}
            onClick={handleApplication}>
            Apply
          </button>
        </div>
      )}
    </div>
  );
}
