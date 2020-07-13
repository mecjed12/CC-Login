import React from 'react';
import Select from 'react-select';
import Persontable from '../table/Persontable';
import Coursetable from '../table/Coursetable';

const options = [
    { value: 'Course', label: 'KURSE' },
    { value: 'Person', label: 'PERSONEN' },
];

export default class Dropdown extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            selectedOption: null,
        }
    }
    
    handelchange = selectedOption => {
        this.setState(
            {selectedOption},
            () => console.log('Option selected:', this.state.selectedOption)
        );
        this.props.toggleClass()
    };
   
    render() {
        return (
            <div>
                <table className="dropdown">
                    <tbody>
                        <tr>
                            <td><Select
                                value={this.state.selectedOption}
                                onChange={ this.handelchange}
                                options={options}
                            /></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        )
    }
}