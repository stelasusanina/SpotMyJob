import React, { useState } from "react";
import { useAuth } from "../../contexts/AuthContext";
import axiosClient from "../../shared/axiosClient";
import "./FileUpload.css";

export default function FileUpload({ jobId, hasApplied }) {
  const [file, setFile] = useState(null);
  const { identify } = useAuth();

  const handleFileChoosing = (event) => {
    setFile(event.target.files[0]);
  };

  const handleApplication = async () => {
    const userId = await identify();

    const formData = new FormData();
    formData.append("jobId", jobId);
    formData.append("userId", userId);
    formData.append("file", file);

    axiosClient
      .post(`${process.env.REACT_APP_API_BASE_URL}/jobs/${jobId}`, formData)
      .then((response) => {
        console.log(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  return (
    <div className="apply-to-job">
      {hasApplied ? (
        <p>You have already applied to this job. See your applications.</p>
      ) : (
        <div>
          <input
            className="choose-file"
            disabled={file}
            type="file"
            onChange={handleFileChoosing}
          />
          {file && (
            <div>
              <p>{file.name}</p>
              <button className="remove-file" onClick={() => setFile(null)}>
                X
              </button>
            </div>
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
