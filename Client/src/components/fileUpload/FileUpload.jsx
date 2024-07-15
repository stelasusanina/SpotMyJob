import React, { useState, useEffect } from "react";
import { useAuth } from "../../contexts/AuthContext";
import axiosClient from "../../shared/axiosClient";

export default function FileUpload ({ jobId, hasApplied}) {
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
      <div>
        {hasApplied ? (
          <p>You have already applied to this job. See your applications.</p>
        ) : (
          <div>
            <h3>Upload File</h3>
            <input disabled={file} type="file" onChange={handleFileChoosing} />
            {file && (
              <div>
                <p>{file.name}</p>
                <button onClick={() => setFile(null)}>X</button>
              </div>
            )}
            <button disabled={!file} onClick={handleApplication}>
              Apply
            </button>
          </div>
        )}
      </div>
    );
};
