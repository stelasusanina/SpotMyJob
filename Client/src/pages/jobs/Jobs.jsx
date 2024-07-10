import React, { useState, useEffect } from "react";
import axios from "axios";
import JobOffer from "../../components/jobOffer/JobOffer";
import { useSearchParams, useNavigate } from "react-router-dom";

export default function Jobs() {
  const [jobs, setJobs] = useState([]);
  const navigate = useNavigate();
  const [searchParams] = useSearchParams();

  useEffect(() => {
    // Function to fetch jobs based on search params
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

    // Fetch jobs based on initial search params
    const jobTitle = searchParams.get("jobTitle");
    fetchJobs(jobTitle);

    // Optionally, if you want to navigate programmatically
    // based on the search params, you can do so here
    if (jobTitle) {
      navigate(`/jobs/search?jobTitle=${jobTitle}`, { replace: true });
    }
  }, [searchParams, navigate]);

  return (
    <div>
      {jobs.map((job) => (
        <JobOffer
          key={job.id}
          job={job}
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
