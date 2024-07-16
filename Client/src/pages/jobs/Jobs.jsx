import React, { useState, useEffect } from "react";
import axios from "axios";
import JobOffer from "../../components/jobOffer/JobOffer";
import { useSearchParams } from "react-router-dom";
import "./Jobs.css";
import SearchBar from "../../components/searchBar/SearchBar";
import Sidebar from "../../components/sidebar/Sidebar";

export default function Jobs() {
  const [jobs, setJobs] = useState([]);
  const [searchParams, setSearchParams] = useSearchParams();

  useEffect(() => {
    const fetchData = async () => {
      const jobTitle = searchParams.get("jobTitle");
      const category = searchParams.get("category");
      const country = searchParams.get("country");

      try {
        const response = await axios.get(
          `${process.env.REACT_APP_API_BASE_URL}/jobs`,
          {
            params: { category, country, jobTitle },
          }
        );
        setJobs(response.data);
      } catch (error) {
        if (error.response && error.response.status === 404) {
          setJobs([]);
        } else {
          console.log(
            "An error occurred while fetching jobs. Please try again later.",
            error
          );
        }
      }
    };

    fetchData();
  }, [searchParams]);

  return (
    <div className="jobs-board">
      <SearchBar className={"jobs"} />
      <div>
        <Sidebar />
        {Array.isArray(jobs) && jobs.length > 0 ? (
          jobs.map((job) => (
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
          ))
        ) : (
          <p>No jobs found for the selected filters.</p>
        )}
      </div>
    </div>
  );
}
