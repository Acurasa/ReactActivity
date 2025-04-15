import { useEffect, useState } from 'react'
import { Container, List, ListItem, ListItemText, Typography } from '@mui/material';
import axios from 'axios';
import ButtonAppBar from './Navbar';
import ActivityDashBoard from '../features/activities/ActivityDashBoard';

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    axios.get<Activity[]>("http://localhost:5015/api/activities")
      .then(response => setActivities(response.data));
  }, []);

  return (
    <>
      <ButtonAppBar/>
      <Container maxWidth = "xl" sx={{mt: 3}}> 
        <ActivityDashBoard activities={activities}/>
      </Container>
    </>
  );
}

export default App;
