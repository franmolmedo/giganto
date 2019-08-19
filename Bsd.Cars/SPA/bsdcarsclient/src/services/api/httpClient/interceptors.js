const successResponse = response => response.data;

const errorResponse = error => console.log({ error });

export { successResponse, errorResponse };
