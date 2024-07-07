import React from "react";
import "./JobOffer.css";

export default function JobOffer({ title, country, city, companyImgUrl, postedOn, isFullTime }) {
    // Format the postedOn date
    const formattedDate = new Date(postedOn).toLocaleDateString();

    return (
      <div className="job-container">
        <div className="job-info">
          <h2>{title}</h2>
          <div className="job-details">
            <div className="detail">
              <p>
                <img
                  src="https://img.icons8.com/?size=100&id=85149&format=png&color=000000"
                  alt="Location Icon"
                />
                {country}, {city}
              </p>
            </div>
            <div className="detail">
              <p>
                <img
                  src="https://img.icons8.com/?size=100&id=3344&format=png&color=000000"
                  alt="Calendar Icon"
                />
                {formattedDate}
              </p>
            </div>
            <div className="detail">
              <p>
                <img
                  src={
                    isFullTime
                      ? "https://img.icons8.com/?size=100&id=109233&format=png&color=000000"
                      : "https://img.icons8.com/?size=100&id=24275&format=png&color=000000"
                  }
                  alt={isFullTime ? "Full Time Icon" : "Part Time Icon"}
                />
                {isFullTime ? "Full Time" : "Part Time"}
              </p>
            </div>
          </div>
        </div>
        <img src={companyImgUrl} alt="Company Logo" />
      </div>
    );
}
