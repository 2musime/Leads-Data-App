import axios from 'axios';
import type Lead from '../types/Lead';

export const submitLead = async (leadData: Lead) => {
  const response = await axios.post('http://localhost:5000/api/lead/submit', leadData);
  return response.data;
};
