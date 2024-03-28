import { check } from "k6";
import http from "k6/http";

export const options = {
  stages: [
    { duration: "10s", target: 20 },
    { duration: "1m40s", target: 20 },
    { duration: "10s", target: 0 },
  ]
};

export default function () {
  const proxyUrl = 'http://localhost:3000';

  const response = http.post(`${proxyUrl}/users`);

  check(response, {
    'response code was 201': (res) => res.status == 201
  });

  const userResponse = http.get(`${proxyUrl}/users/${response.body}`);

  check(userResponse, {
    'response code was 200': (res) => res.status == 200
  });
}
