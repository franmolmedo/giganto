import { createInstance } from "./httpClient/";

const getPaginatedOrders = ({ skip, take }) =>
  createInstance().post("/Orders/All?api-version=1.0", {
    skip,
    take
  });

export { getPaginatedOrders };
