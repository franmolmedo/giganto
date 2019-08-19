import { createAction } from "redux-act";

import { getPaginatedOrders } from '../../../services';

const GET_DEFAULT_ORDERS_REQUEST = "GET_DEFAULT_ORDERS_REQUEST";
const GET_DEFAULT_ORDERS_DONE = "GET_DEFAULT_ORDERS_DONE";
const GET_DEFAULT_ORDERS_ERROR = "GET_DEFAULT_ORDERS_ERROR";

const getDefaultOrdersRequest = createAction(GET_DEFAULT_ORDERS_REQUEST);
const getDefaultOrdersDone = createAction(GET_DEFAULT_ORDERS_DONE);
const getDefaultOrdersError = createAction(GET_DEFAULT_ORDERS_ERROR);

const getDefaultOrders = () => async dispatch => {
    dispatch(getDefaultOrdersRequest);
    try {
        const orders = await getPaginatedOrders({ skip: 0, take: 10 });
        dispatch(getDefaultOrdersDone(orders));
    } catch (error) {
        dispatch(getDefaultOrdersError())
    }
}

export { getDefaultOrders, getDefaultOrdersDone };
