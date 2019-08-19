import { connect } from "react-redux";

import { getDefaultOrders } from '../../state'

import { Main } from "./Main";

const mapStateToProps = ({ orders }) => ({ orders });

const mapDispatchToProps = dispatch => ({
  getInitialOrders: () => dispatch(getDefaultOrders())
});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Main);
