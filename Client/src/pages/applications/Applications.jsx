import {React, useEffect, useState } from "react";
import axiosClient from "../../shared/axiosClient";
import JobWithApplications from "../../components/jobWithApplications/JobWithApplications";

export default function Applications() {
    const [applications, setApplications] = useState([]);

    useEffect(() => {
      const fetchApplications = async () => {
        try {
          const response = await axiosClient.get(
            `${process.env.REACT_APP_API_BASE_URL}/admin/allJobApplications`
          );
          setApplications(response.data);
          console.log(response.data);
        } catch (error) {
          console.error("Error fetching applications:", error);
        }
      };

      fetchApplications();
    }, []);
    return (
      <div className="all-job-applications">
        <h3>All Job Applications</h3>
        {applications.map((application) => (
          <JobWithApplications
            key={application.id}
            jobId={application.id}
            companyName={application.companyName}
            jobTitle={application.title}
            city={application.city}
            country={application.country}
            users={application.users}
          />
        ))}
      </div>
    );
}