import React from 'react';
import './Fileinput.css';
import Select from 'react-select';

const options = [
    { value: '1', label: 'Spalte' },
    { value: '2', label: 'Zeile 2' },
    { value: '3', label: 'Zeile 3' },
];

export default class Fileinput extends React.Component {
    state = {
        id: null,
        firstName: null,
        lastName: null,
    };

    config = {
        id: 1,
        firstName: 2,
        lastName: 3
    }
   
    handleChange = (key, value) => {
        console.log(value)
        this.setState({
            [key]: value
        })
    }

    render() {
        const { selectedOption } = this.state;
        const { selectedOption1 } = this.state;
        const { selectedOption2 } = this.state;

        console.log(this.state)

        return (
            <div className="input-container">
                <table>
                    <tr>
                        <th></th>
                        <th></th>
                    </tr>
                    <tr>
                        <td>ID</td>
                        <td> <Select
                            name="idInput"
                            value={selectedOption}
                            onChange={(newValue) => this.handleChange('id', newValue)}
                            options={options}
                        /></td>

                    </tr>
                    <tr>
                        <td>Firstname</td>
                        <td> <Select
                            value={selectedOption1}
                            onChange={(newValue) => this.handleChange('firstName', newValue)}
                            options={options}
                        /></td>
                    </tr>
                    <tr>
                        <td>Lastname</td>
                        <td> <Select
                            value={selectedOption2}
                            onChange={(newValue) => this.handleChange('lastName', newValue)}
                            options={options}
                        /></td>
                    </tr>
                </table>



            </div>
        )
    }
}