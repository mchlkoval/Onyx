import React from 'react'
import { observer } from 'mobx-react-lite'
import { LineChart, CartesianGrid, Tooltip, Line, Legend, XAxis, YAxis, ResponsiveContainer } from 'recharts'
import { Container, Segment, Header } from 'semantic-ui-react'

const Progress : React.FC = () => {

    const data = [
        {
            name: "Monday", calories: 980, avgHR: 150
        },
        {
            name: "Tuesday", calories: 750, avgHR: 140
        },
        {
            name: "Wednedsay", calories: 900, avgHR: 145
        },
        {
            name: "Thursday", calories: 1000, avgHR: 155
        },
        {
            name: "Friday", calories: 600, avgHR: 130
        },
        {
            name: "Saturday", calories: 800, avgHR: 135
        },
        {
            name: "Sunday", calories: 1200, avgHR: 165
        }
    ]

    return (
        <Container>
            <Segment>
                <Segment.Group>
                    <Header>Calories & Avg. Heart Rate</Header>
                </Segment.Group>
                
                <ResponsiveContainer width='100%' aspect={4.0/3.0}>
                    <LineChart 
                        height={500}
                        data={data}
                    >
                        <XAxis dataKey="name"/>
                        <YAxis dataKey="calories"/>
                        <CartesianGrid strokeDasharray="3 3"/>
                        <Tooltip/>
                        <Legend/>
                        <Line type='monotone' dataKey="calories" stroke="#8884d8" activeDot={{r: 6}}/>
                        <Line type="monotone" dataKey="avgHR" stroke="#82ca9d"/>
                    </LineChart>
                </ResponsiveContainer>
            </Segment>
        </Container>
        
    )
}

export default observer(Progress)
