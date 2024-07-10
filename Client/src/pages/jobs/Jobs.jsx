import React, { useState, useEffect } from "react";
import axios from "axios";
import JobOffer from "../../components/jobOffer/JobOffer";
import { useSearchParams, useNavigate } from "react-router-dom";
import "./Jobs.css";

export default function Jobs() {
  const [jobs, setJobs] = useState([]);
  const navigate = useNavigate();
  const [searchParams] = useSearchParams();

  useEffect(() => {
    const fetchJobs = async (jobTitle) => {
      try {
        let response;
        if (jobTitle) {
          response = await axios.get(
            `${process.env.REACT_APP_API_BASE_URL}/jobs/search?jobTitle=${jobTitle}`
          );
        } else {
          response = await axios.get(`${process.env.REACT_APP_API_BASE_URL}/jobs`);
        }
        setJobs(response.data);
        console.log(response.data);
      } catch (error) {
        console.error("Error fetching jobs:", error);
      }
    };

    const jobTitle = searchParams.get("jobTitle");
    fetchJobs(jobTitle);

    if (jobTitle) {
      navigate(`/jobs/search?jobTitle=${jobTitle}`);
    }
  }, [searchParams, navigate]);

  return (
    <div className="jobs-board">
      {jobs.map((job) => (
        <JobOffer
          key={job.id}
          id={job.id}
          title={job.title}
          companyName={job.companyName}
          companyImgUrl={job.companyImgUrl}
          country={job.country}
          city={job.city}
          postedOn={job.postedOn}
          isFullTime={job.isFullTime}
        />
      ))}
    </div>
  );
}
