import axios from "axios";

const axiosClient = new axios.create({ withCredentials: true });

export default axiosClient;
