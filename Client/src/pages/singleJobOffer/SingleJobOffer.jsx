import axios from "axios";
import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";

export default function SingleJobOffer() {
    const { jobId } = useParams();
    const [job, setJob] = useState(null);

    useEffect(() => {
        const fetchJob = async () => {
            try {
                const response = await axios.get(`${process.env.REACT_APP_API_BASE_URL}/jobs/${jobId}`);
                const data = await response.data;
                setJob(data);
                console.log(data);
            } catch (error) {
                console.error("Error fetching job:", error);
            }
        };

        fetchJob();
    }, [jobId]);

    return (
      <div className="container">
        {job && (
          <div className="container">
            <h2>
              {job.title} at{" "}
              <span className="company-name">{job.companyName}</span>{" "}
            </h2>
            <div className="details-block">
              <div className="detail">
                <img
                  src="https://img.icons8.com/?size=100&id=85149&format=png&color=000000"
                  alt="Location Icon"
                />
                <p>
                  {job.country}, {job.city}
                </p>
              </div>
              <div className="detail">
                <img
                  src="https://img.icons8.com/?size=100&id=3344&format=png&color=000000"
                  alt="Calendar Icon"
                />
                <p>{new Date(job.postedOn).toLocaleDateString()}</p>
              </div>
              <div className="detail">
                <img
                  src={
                    job.isFullTime
                      ? "https://img.icons8.com/?size=100&id=109233&format=png&color=000000"
                      : "https://img.icons8.com/?size=100&id=24275&format=png&color=000000"
                  }
                  alt={job.isFullTime ? "Full Time Icon" : "Part Time Icon"}
                />
                <p>{job.isFullTime ? "Full Time" : "Part Time"}</p>
              </div>
              <div className="detail">
                <img
                  src="https://img.icons8.com/?size=100&id=46218&format=png&color=000000"
                  alt="Category Icon"
                />
                <p>{job.jobCategory}</p>
              </div>
            </div>
            <p className="total-applications">
              Total job applications: {job.jobApplicationsCount}
            </p>
            {job.companyDescription && (
              <p className="company-description">{job.companyDescription}</p>
            )}
            <div className="sections">
              {job.sections.map((section) => (
                <div key={section.id} className="section">
                  <h3>{section.name}</h3>
                  <ul>
                    {section.content
                      .split(".")
                      .map((sentence) => sentence.trim())
                      .filter((sentence) => sentence.length > 0)
                      .map((sentence, index) => (
                        <li key={index}>{sentence}</li>
                      ))}
                  </ul>
                </div>
              ))}
            </div>
            <p>Does it sound like the perfect job for you? Apply now!</p>
          </div>
        )}
      </div>
    );
}