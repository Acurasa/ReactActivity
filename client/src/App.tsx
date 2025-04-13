import { useEffect, useState } from 'react'
import './App.css'
import { List, ListItemText, Typography } from '@mui/material';
import axios from 'axios';

function App() {

  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(()=> {
    axios.get<Activity[]>("http://localhost:5015/api/activities")
    .then(response => setActivities(response.data))

    return () => {}
  }, []);
  return (
    <>
      <Typography>React Activities</Typography>
      <List>
        {activities.map(activity=>
        (
          <ListItemText key={activity.id}>
            {activity.title}
          </ListItemText>
        )                                                                                     
        )}
      </List>
    </>
  )
}

export default App
