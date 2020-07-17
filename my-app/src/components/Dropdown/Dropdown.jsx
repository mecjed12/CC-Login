import React from 'react';
import '../Dropdown/Dropdown.css';
import Select from 'react-select';


const options = [
    { value: 'course', label: 'Kurse' },
    { value: 'person', label: 'Personen' },
];
export default class Dropdown extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            selectionOption: null,
        }
    }
    handelchange = selectionOption => {
        this.setState(
            { selectionOption }
        );
        this.props.toggleClass(selectionOption.value)
    };

    
    createOptions() {
        options = [{ value: null, label: 'Spalte auswählen ...' }]
        for (var i = 0; i < this.state.properties.length; i++) {
            options.push({ value: i, label: 'Spalte ' + (+i + 1) })

        }
    }
    render() {
        return (
            <div className="input-container">
                <table>
                    <tbody>
                        <tr>
                            <td><Select
                                value={this.state.selectionOption}
                                onChange={this.handelchange}
                                options={options}
                            /></td>
                        </tr>
                    </tbody>
                </table>
            </div>


        )

    }
}