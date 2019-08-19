import axios from "axios";

import { successResponse, errorResponse } from "./interceptors";

const baseServiceInstance = () =>
  axios.create({
    baseURL: "https://localhost:44341/api"
  });

export const createInstance = config => {
  const instance = baseServiceInstance();
  instance.interceptors.response.use(successResponse, errorResponse);
  return instance;
};
