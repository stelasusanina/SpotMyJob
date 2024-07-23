import React, { useState } from "react";
import "./JobWithApplications.css";
import axiosClient from "../../shared/axiosClient";

export default function JobWithApplications({ jobId, companyName, jobTitle, city, country, users }) {
  const [isExpanded, setIsExpanded] = useState(false);

  const handleStatusChange = async (event, userId) => {
    const status = event.target.value;

    const formData = new FormData();
    formData.append("userId", userId);
    formData.append("jobOfferId", jobId);
    formData.append("status", status);

    try {
      await axiosClient.put(
        `${process.env.REACT_APP_API_BASE_URL}/admin/changeApplicationStatus`,
        formData
      );
      console.log("Status changed successfully");
    } catch (error) {
      console.error("Error changing status:", error);
    }
  };

  const toggleExpandJob = () => {
    setIsExpanded(!isExpanded);
  };

  return (
    <div className="job-with-applications">
      <div className="application-header">
        <p className="application-title">
          {jobTitle} at {companyName} {`(${city}, ${country})`}
        </p>
        <span className="applications-count">Total Applications: {users.length}</span>
        <span className="toggle-job" onClick={toggleExpandJob}>
          {isExpanded ? (
            <i className="fa-solid fa-caret-up"></i>
          ) : (
            <i className="fa-solid fa-caret-down"></i>
          )}
        </span>
      </div>
      {isExpanded && (
        <div className="application-details">
          {users.map((user) => (
            <div key={user.applicationUserId} className="application-user">
              {user.applicationUserProfilePhotoUrl ? (
                <img
                  src={user.applicationUserProfilePhotoUrl}
                  alt="profile picture"
                  className="profile-picture"
                />
              ) : (
                <img
                  src="https://www.iprcenter.gov/image-repository/blank-profile-picture.png/@@images/image.png"
                  alt="profile picture"
                  className="profile-picture"
                />
              )}

              <div className="application-details">
                <p>
                  <span>User id:</span> {user.applicationUserId}
                </p>
                <p>
                  <span>User names:</span> {user.applicationUserNames}
                </p>
                <p>
                  <span>File uploaded:</span> {user.uploadedFileName}
                </p>
                <p>
                  <span>Applied on:</span>{" "}
                  {new Date(user.appliedOn).toLocaleString()}
                </p>
                <p>
                  <span>Status:</span>{" "}
                  <span className={`status-${user.status}`}>{user.status}</span>
                  <select
                    className="change-status"
                    onChange={(event) =>
                      handleStatusChange(event, user.applicationUserId)
                    }
                    defaultValue={""}>
                    <option value="" disabled>
                      Change status
                    </option>
                    <option value="Applied">Applied</option>
                    <option value="In-progress">In Progress</option>
                    <option value="Completed">Completed</option>
                    <option value="Rejected">Rejected</option>
                  </select>
                </p>
              </div>
            </div>
          ))}
        </div>
      )}
    </div>
  );
}