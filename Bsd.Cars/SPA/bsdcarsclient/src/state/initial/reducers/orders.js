import { createReducer } from "redux-act";

import { getDefaultOrdersDone } from "../actions/defaultOrders";

export default createReducer(
  {
    [getDefaultOrdersDone]: (_, payload) => payload
  },
  []
);
