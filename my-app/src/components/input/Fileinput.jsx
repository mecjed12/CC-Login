import React from 'react';
import './Fileinput.css';
import Select from 'react-select';

const options = [
    { value: '0', label: 'Keine Daten' },
    { value: '1', label: 'Spalte 1' },
    { value: '2', label: 'Spalte 2' },
    { value: '3', label: 'Spalte 3' },
    { value: '4', label: 'Spalte 4' },
    { value: '5', label: 'Spalte 5' },
    { value: '6', label: 'Spalte 6' },
    { value: '7', label: 'Spalte 7' },
    { value: '8', label: 'Spalte 8' },
    { value: '9', label: 'Spalte 9' },
    { value: '10', label: 'Spalte 10' },
    { value: '11', label: 'Spalte 11' },
    { value: '12', label: 'Spalte 12' },
    { value: '13', label: 'Spalte 13' },
    { value: '14', label: 'Spalte 14' },
    { value: '15', label: 'Spalte 15' },


];

export default class Fileinput extends React.Component {
    constructor(props) {
        super(props);
        this.state = {

        Keinedaten: null,
        firstName: null,
        lastName: null,
        title: null,
        SV_Number: null,
        Geb_Date: null,
        Gender: null,
        busy: null,
        busy_by: null,
        picture: null,
        function: null,
        aktiv: null,
        deleted_inaktiv: null,
        newsletter_flag: null,
        created: null,
        modify: null,
        }
    }
      
    handleChange = (key, value) => {
        console.log(value)
        this.setState({
            [key]: value.value
        })
    }

    render() {
        
        const { selectedOption1 } = this.state;
        const { selectedOption2 } = this.state;
        const { selectedOption3 } = this.state;
        const { selectedOption4 } = this.state;
        const { selectedOption5 } = this.state;
        const { selectedOption6 } = this.state;
        const { selectedOption7 } = this.state;
        const { selectedOption8 } = this.state;
        const { selectedOption9 } = this.state;
        const { selectedOption10 } = this.state;
        const { selectedOption11 } = this.state;
        const { selectedOption12 } = this.state;
        const { selectedOption13 } = this.state;
        const { selectedOption14 } = this.state;
        const { selectedOption15 } = this.state;


        console.log(this.state)

        return (
            <div className="input-container">
                <table>
                   
                    
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
                    <tr>
                        <td>Title</td>
                        <td> <Select
                            value={selectedOption3}
                            onChange={(newValue) => this.handleChange('title', newValue)}
                            options={options}
                        /></td>
                    </tr>  <tr>
                        <td>SV-Number</td>
                        <td> <Select
                            value={selectedOption4}
                            onChange={(newValue) => this.handleChange('SV_Number', newValue)}
                            options={options}
                        /></td>
                    </tr>  <tr>
                        <td>Geb-Date</td>
                        <td> <Select
                            value={selectedOption5}
                            onChange={(newValue) => this.handleChange('Geb_Date', newValue)}
                            options={options}
                        /></td>
                    </tr>  <tr>
                        <td>Gender</td>
                        <td> <Select
                            value={selectedOption6}
                            onChange={(newValue) => this.handleChange('Gender', newValue)}
                            options={options}
                        /></td>
                    </tr>  <tr>
                        <td>Busy</td>
                        <td> <Select
                            value={selectedOption7}
                            onChange={(newValue) => this.handleChange('busy', newValue)}
                            options={options}
                        /></td>
                    </tr>  <tr>
                        <td>Busy-by</td>
                        <td> <Select
                            value={selectedOption8}
                            onChange={(newValue) => this.handleChange('busy_by', newValue)}
                            options={options}
                        /></td>
                    </tr>  <tr>
                        <td>Picture</td>
                        <td> <Select
                            value={selectedOption9}
                            onChange={(newValue) => this.handleChange('picture', newValue)}
                            options={options}
                        /></td>
                    </tr>  <tr>
                        <td>Function</td>
                        <td> <Select
                            value={selectedOption10}
                            onChange={(newValue) => this.handleChange('function', newValue)}
                            options={options}
                        /></td>
                    </tr>  <tr>
                        <td>Aktiv</td>
                        <td> <Select
                            value={selectedOption11}
                            onChange={(newValue) => this.handleChange('aktiv', newValue)}
                            options={options}
                        /></td>
                    </tr>  <tr>
                        <td>Deletet-inaktiv</td>
                        <td> <Select
                            value={selectedOption12}
                            onChange={(newValue) => this.handleChange('deleted_inaktiv', newValue)}
                            options={options}
                        /></td>
                    </tr>  <tr>
                        <td>Newsletter-flag</td>
                        <td> <Select
                            value={selectedOption13}
                            onChange={(newValue) => this.handleChange('newsletter_flag', newValue)}
                            options={options}
                        /></td>
                    </tr>  <tr>
                        <td>Created-date</td>
                        <td> <Select
                            value={selectedOption14}
                            onChange={(newValue) => this.handleChange('created', newValue)}
                            options={options}
                        /></td>
                    </tr>  <tr>
                        <td>Modify-date</td>
                        <td> <Select
                            value={selectedOption15}
                            onChange={(newValue) => this.handleChange('modify', newValue)}
                            options={options}
                        /></td>
                    </tr>
                </table>



            </div>
        )
    }
}