import React, { useState } from "react";
import axios from "axios";
import { useAuth } from "../../contexts/AuthContext";

export default function FileUpload ({ jobId, hasApplied}) {
    const [file, setFile] = useState(null);
    const { user } = useAuth();

    const handleFileChoosing = (event) => {
        setFile(event.target.files[0]);
    };

    const handleApplication = () => {
        const formData = new FormData();
        formData.append("jobId", jobId);
        formData.append("userId", user.id);
        formData.append("file", file);

        axios
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
            {!hasApplied ? (
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
            ) : (
                <p>You have applied for this job! See your applications.</p>
            )}
        </div>
    );
};
