import { createStore, combineReducers, applyMiddleware } from "redux";
import thunk from "redux-thunk";

import orders from "./initial/reducers/orders";

const reducers = { orders };

const combinedReducers = combineReducers(reducers);

const store = createStore(combinedReducers, applyMiddleware(thunk));

export { store };
