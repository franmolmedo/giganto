import React from "react";

const ListItem = ({
  item: { carFrame, model, licensePlate, deliveryDate }
}) => (
  <li>
    <div>{carFrame}</div>
    <div>{model}</div>
    <div>{licensePlate}</div>
    <div>{deliveryDate}</div>
  </li>
);

export { ListItem };
