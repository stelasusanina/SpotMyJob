import React, { useState, useEffect } from "react";
import "./JobOffer.css";
import { Link } from "react-router-dom";
import { useAuth } from "../../contexts/AuthContext";
import axiosClient from "../../shared/axiosClient";

export default function JobOffer({
  id,
  title,
  companyName,
  companyImgUrl,
  country,
  city,
  postedOn,
  isFullTime,
}) {
  const [userId, setUserId] = useState(null);
  const [role, setRole] = useState(null);
  const { identify, getRole } = useAuth();
  const formattedDate = new Date(postedOn).toLocaleDateString();

  useEffect(() => {
    const fetchUser = async () => {
      const userIdResponse = await identify();
      setUserId(userIdResponse);
      const roleResponse = await getRole();
      setRole(roleResponse);
    };
  
    fetchUser();
  }, [identify]);
  

  const deleteJob = async () => {
    try {
      await axiosClient.delete(
        `${process.env.REACT_APP_API_BASE_URL}/admin/deleteJobOffer/${id}`,
      );
      window.location.reload();
    } catch (error) {
      console.log(error);
    }
  };


  console.log(userId, role);
  return (
    <div className="job-container">
      <div className="job-info">
        <Link className="job-title" to={userId ? `/jobs/${id}` : `/auth/login`}>
          <h2>{title}</h2>
        </Link>
        <div className="job-details">
          <div>
            <img
              src="https://img.icons8.com/?size=100&id=85149&format=png&color=000000"
              alt="Location Icon"
            />
            <p>
              {country}, {city}
            </p>
          </div>
          <div>
            <img
              src="https://img.icons8.com/?size=100&id=3344&format=png&color=000000"
              alt="Calendar Icon"
            />
            <p>{formattedDate}</p>
          </div>
          <div>
            <img
              src={
                isFullTime
                  ? "https://img.icons8.com/?size=100&id=109233&format=png&color=000000"
                  : "https://img.icons8.com/?size=100&id=24275&format=png&color=000000"
              }
              alt={isFullTime ? "Full Time Icon" : "Part Time Icon"}
            />
            <p>{isFullTime ? "Full Time" : "Part Time"}</p>
          </div>
        </div>
      </div>
      <img className="company-logo" src={companyImgUrl} alt="Company Logo" />
      {userId &&  role === "Admin" && (
        <button onClick={deleteJob} className="delete-button">
          <i class="fa-solid fa-circle-xmark"></i>
        </button>
      )}
    </div>
  );
}
