import React from "react";
import "./JobOffer.css";
import { Link } from "react-router-dom";
import { useAuth } from "../../contexts/AuthContext";

export default function JobOffer({id, title, country, city, companyImgUrl, postedOn, isFullTime }) {
    const { identify } = useAuth();
    const formattedDate = new Date(postedOn).toLocaleDateString();

    return (
      <div className="job-container">
        <div className="job-info">
          <Link
            className="job-title"
            to={identify() ? `/jobs/${id}` : `/auth/login`}>
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
      </div>
    );
}
