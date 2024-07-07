import {React,useState, useEffect} from "react";
import axios from "axios";
import JobOffer from "../../components/jobOffer/JobOffer";

export default function Jobs() {
    const [jobs, setJobs] = useState([]);

    useEffect(() => {
        const fetchJobs = async () => {
            try {
                const response = await axios.get(`${process.env.REACT_APP_API_BASE_URL}/jobs`);
                setJobs(response.data);
                console.log(response.data);
            } catch (error) {
                console.error("Error fetching jobs:", error);
            }
        };

        fetchJobs();
    }, []); 

    return jobs.map((job) => (
      <JobOffer
        key={job.id}
        title={job.title}
        country={job.country}
        city={job.city}
        companyImgUrl={job.companyImgUrl}
        postedOn={job.postedOn}
        isFullTime={job.isFullTime}
      />
    ));
}