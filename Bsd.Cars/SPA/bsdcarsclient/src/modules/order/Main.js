import React, { useEffect } from "react";

import { NoItems } from "./Main/NoItems";
import { ItemList } from "./Main/ItemList";

const Main = ({ orders = { data: [], total: 0 }, getInitialOrders = () => { } }) => {
  useEffect(() => { getInitialOrders() },
    // eslint-disable-next-line react-hooks/exhaustive-deps
    []);

  return orders.total === 0 ? <NoItems /> : <ItemList items={orders.data} />;
};

export { Main };
