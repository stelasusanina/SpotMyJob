import React, { useState, useEffect } from "react";
import axios from "axios";
import JobOffer from "../../components/jobOffer/JobOffer";
import { useSearchParams } from "react-router-dom";
import "./Jobs.css";
import SearchBar from "../../components/searchBar/SearchBar";

export default function Jobs() {
  const [jobs, setJobs] = useState([]);
  const [searchParams] = useSearchParams();

  useEffect(() => {
    const fetchData = async () => {
      try {
        let response;
        const jobTitle = searchParams.get("jobTitle");
        const category = searchParams.get("category");

        if (jobTitle) {
          response = await axios.get(
            `${process.env.REACT_APP_API_BASE_URL}/jobs/search?jobTitle=${jobTitle}`
          );
        } else if (category) {
          response = await axios.get(
            `${process.env.REACT_APP_API_BASE_URL}/jobs/filter?category=${category}`
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

    fetchData();
  }, [searchParams]);

  return (
    <div className="jobs-board">
      <SearchBar className={"jobs"}/>
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
