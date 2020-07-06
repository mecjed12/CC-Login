import React from 'react';
import './Fileinput.css';
import Select from 'react-select';

const options = [
    { value: null, label: 'Keine Daten' },
    { value: '0', label: 'Spalte 1' },
    { value: '1', label: 'Spalte 2' },
    { value: '2', label: 'Spalte 3' },
    { value: '3', label: 'Spalte 4' },
    { value: '4', label: 'Spalte 5' },
    { value: '5', label: 'Spalte 6' },
    { value: '6', label: 'Spalte 7' },
    { value: '7', label: 'Spalte 8' },
    { value: '8', label: 'Spalte 9' },
    { value: '9', label: 'Spalte 10' },
    { value: '10', label: 'Spalte 11' },
    { value: '11', label: 'Spalte 12' },
    { value: '12', label: 'Spalte 13' },
    { value: '13', label: 'Spalte 14' },
    { value: '14', label: 'Spalte 15' },
];

export default class Fileinput extends React.Component {
    constructor(props) {
        super(props);
        this.state = {

            Keinedaten: null,
            name1: null,
            name2: null,
            title: null,
            svNumber: null,
            date: null,
            gender: null,
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
        if (this.state === options.label) {
            alert("gleicher wert")

        }
    }

    render() {
        const { selectcolumn } = this.state;
        console.log(this.state)
        return (
            <div className="input-container">
                <table>
                    <tbody>
                        <tr>
                            <td>FirstName:</td>
                            <td> <Select
                                value={selectcolumn}
                                onChange={(newValue) => this.handleChange('name1', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Lastname:</td>
                            <td> <Select
                                value={selectcolumn}
                                onChange={(newValue) => this.handleChange('name2', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Title:</td>
                            <td> <Select
                                value={selectcolumn}
                                onChange={(newValue) => this.handleChange('title', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>SV-Number:</td>
                            <td> <Select
                                value={selectcolumn}
                                onChange={(newValue) => this.handleChange('svNumber', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Geb-Date:</td>
                            <td> <Select
                                value={selectcolumn}
                                onChange={(newValue) => this.handleChange('date', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Gender:</td>
                            <td> <Select
                                value={selectcolumn}
                                onChange={(newValue) => this.handleChange('gender', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Busy:</td>
                            <td> <Select
                                value={selectcolumn}
                                onChange={(newValue) => this.handleChange('busy', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Busy-by:</td>
                            <td> <Select
                                value={selectcolumn}
                                onChange={(newValue) => this.handleChange('busy_by', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Picture:</td>
                            <td> <Select
                                value={selectcolumn}
                                onChange={(newValue) => this.handleChange('picture', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Function:</td>
                            <td> <Select
                                value={selectcolumn}
                                onChange={(newValue) => this.handleChange('function', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Aktiv:</td>
                            <td> <Select
                                value={selectcolumn}
                                onChange={(newValue) => this.handleChange('aktiv', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Deletet-inaktiv:</td>
                            <td> <Select
                                value={selectcolumn}
                                onChange={(newValue) => this.handleChange('deleted_inaktiv', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Newsletter-flag:</td>
                            <td> <Select
                                value={selectcolumn}
                                onChange={(newValue) => this.handleChange('newsletter_flag', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Created-date:</td>
                            <td> <Select
                                value={selectcolumn}
                                onChange={(newValue) => this.handleChange('created', newValue)}
                                options={options}
                            /></td>
                        </tr>
                        <tr>
                            <td>Modify-date:</td>
                            <td> <Select
                                value={selectcolumn}
                                onChange={(newValue) => this.handleChange('modify', newValue)}
                                options={options}
                            /></td>
                        </tr>
                    </tbody>
                </table>
                <div type="button" className="button-click" onClick={() => this.props.upload(this.state)}>Upload</div>
            </div>
        )
    }
}