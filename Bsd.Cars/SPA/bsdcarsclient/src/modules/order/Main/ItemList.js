import React from "react";

import { ListItem } from "./ItemList/ListItem";

const ItemList = ({ items = [] }) => (
  <ul>
    {items.map(item => (
      <ListItem key={item.id} item={item} />
    ))}
  </ul>
);

export { ItemList };
